// @ts-check
import { acceptHMRUpdate, defineStore } from 'pinia'
import axios from 'axios'
import type { AddProject, FocusedIssue, Issue, Project, UpdateProject } from '~/types/interfaces'

import { useUserStore } from '~/stores/users'
import eventService from '~/composables/eventService'

interface State {
  OpenIssues: Issue[] | null
  InProgress: Issue[] | null
  Review: Issue[] | null
  Closed: Issue[] | null
  Projects: Project[] | null
  LoadedProjectId: string| null
  FocusedIssue: FocusedIssue|null
  ShowFocusedIssue: boolean

}

export const useProjectStore = defineStore({
  id: 'Projects',
  state: (): State => ({
    Projects: null,
    LoadedProjectId: null,
    OpenIssues: null,

    InProgress: null,

    Review: null,

    Closed: null,
    FocusedIssue: null,

    /*
    FocusedIssue: {
      id: 'default',
      title: 'default',
      description: 'default',
      date: 'default',
      urgency: 'default',
      type: 'default',
      progress: 'Defult',
    }, */
    ShowFocusedIssue: false,
  }),

  actions: {

    // =========================================
    // ===========   FETCH Projects  ===============:w
    // =========================================
    async fetchProjects() {
      const userStore = useUserStore()
      if (userStore.getToken) {
        await eventService.getAllProjects(userStore.getToken)
          .then((response) => {
            return this.Projects = response.data
          }).catch((error) => {
            if (axios.isAxiosError(error)) {
              if (error.response) {
                console.log(error.response?.data)
                console.log(error.response.status)
                console.log(error.response.headers)
              }
              else if (error.request) {
                // The request was made but no response was received
                // `error.request` is an instance of XMLHttpRequest in the browser and an instance of
                // http.ClientRequest in node.js
                console.log(error.request)
              }
              else {
                // Something happened in setting up the request that triggered an Error
                console.log('Error', error.message)
              }
            }
          })
      }
    },

    // =========================================
    // ===========   FETCH Project Issues  ===============
    // =========================================

    async fetchProjectRelatedIssues(projectId: string) {
      if (projectId === this.LoadedProjectId) { return null }
      else {
        this.LoadedProjectId = projectId
        await this.fetchOpenIssues(projectId)
        await this.fetchAllReviewIssues(projectId)
        await this.fetchIssuesInProgress(projectId)
        await this.fetchClosedIssues(projectId)
      }
      console.log(projectId)
    },

    // =========================================
    // ===========   ADD Project  ===============
    // =========================================

    async addProject(newProject: AddProject) {
      const userStore = useUserStore()

      if (userStore.getToken) {
        await eventService.addNewProject(userStore.getToken, newProject)
          .then((response) => {
            if (response.status === 200)
              return this.Projects?.push(response.data)
          }).catch((error) => {
            if (axios.isAxiosError(error)) {
              if (error.response) {
                console.log(error.response?.data)
                console.log(error.response.status)
                console.log(error.response.headers)
              }
              else if (error.request) {
                console.log(error.request)
              }
              else {
                console.log('Error', error.message)
              }
            }
          })
      }
    },

    // =========================================
    // ===========   DELETE Project  ===============
    // =========================================

    async deleteProject() {
      const userStore = useUserStore()
      const projectId = this.getLoadedProjectId
      if (userStore.getToken && projectId) {
        await eventService.deleteProject(userStore.getToken, projectId)
          .then((response) => {
            if (response.status === 200) {
              this.Projects = this.Projects!.filter((p) => {
                return p.projectId !== projectId
              })
              this.OpenIssues = this.OpenIssues!.filter((o) => {
                return o.projectId !== projectId
              })
              this.Closed = this.Closed!.filter((c) => {
                return c.projectId !== projectId
              })
              this.InProgress = this.InProgress!.filter((c) => {
                return c.projectId !== projectId
              })
              return this.Review = this.Review!.filter((c) => {
                return c.projectId !== projectId
              })
            }
          }).catch((error) => {
            if (axios.isAxiosError(error)) {
              if (error.response) {
                console.log(error.response?.data)
                console.log(error.response.status)
                console.log(error.response.headers)
              }
              else if (error.request) {
                console.log(error.request)
              }
              else {
                console.log('Error', error.message)
              }
            }
          })
      }
    },

    // =========================================
    // ===========   Updated Project  ===============
    // =========================================

    async updateProject(project: UpdateProject) {
      const userStore = useUserStore()
      if (userStore.getToken && project) {
        await eventService.updateProject(userStore.getToken, project)
          .then((response) => {
            if (response.status === 200)
              console.log(response.status)
          }).catch((error) => {
            if (axios.isAxiosError(error)) {
              if (error.response) {
                console.log(error.response?.data)
                console.log(error.response.status)
                console.log(error.response.headers)
              }
              else if (error.request) {
                console.log(error.request)
              }
              else {
                console.log('Error', error.message)
              }
            }
          })
      }
    },
    // =========================================
    // ===========   FETCH OPENISSUES  ===============
    // only udpate don,t refresh list, state persists in Pinia while on page and gets loaded from db upon mount
    // =========================================

    async fetchOpenIssues(projectId: string) {
      const userStore = useUserStore()

      if (userStore.getToken) {
        await eventService.getAllOpenIssues(userStore.getToken, projectId)
          .then((response) => {
            this.OpenIssues = response.data
          }).catch((error) => {
            if (axios.isAxiosError(error)) {
              if (error.response) {
                console.log(error.response?.data)
                console.log(error.response.status)
                console.log(error.response.headers)
              }
              else if (error.request) {
                console.log(error.request)
              }
              else {
                console.log('Error', error.message)
              }
            }
          })
      }
    },

    // =========================================
    // ===========   FETCH ISSUES IN PROGRESS  ===============
    // only udpate don,t refresh list, state persists in Pinia while on page and gets loaded from db upon mount
    // =========================================

    async fetchIssuesInProgress(projectId: string) {
      const userStore = useUserStore()

      if (userStore.getToken) {
        await eventService.getAllIssuesInProgress(userStore.getToken, projectId)
          .then((response) => {
            this.InProgress = response.data
          }).catch((error) => {
            if (axios.isAxiosError(error)) {
              if (error.response) {
                console.log(error.response?.data)
                console.log(error.response.status)
                console.log(error.response.headers)
              }
              else if (error.request) {
                console.log(error.request)
              }
              else {
                console.log('Error', error.message)
              }
            }
          })
      }
    },

    async deleteIssue(issue: FocusedIssue) {
      console.log(issue)
    },

    // =========================================
    // ===========   FETCH ISSUES TO BE TESTED   ===============
    // only udpate don,t refresh list, state persists in Pinia while on page and gets loaded from db upon mount
    // =========================================

    async fetchAllReviewIssues(projectId: string) {
      const userStore = useUserStore()
      if (userStore.getToken) {
        await eventService.getAllReviewIssues(userStore.getToken, projectId)
          .then((response) => {
            this.Review = response.data
          }).catch((error) => {
            if (axios.isAxiosError(error)) {
              if (error.response) {
                console.log(error.response?.data)
                console.log(error.response.status)
                console.log(error.response.headers)
              }
              else if (error.request) {
                console.log(error.request)
              }
              else {
                console.log('Error', error.message)
              }
            }
          })
      }
    },

    // =========================================
    // ===========   FETCH CLOSED ISSUES  ===============
    // only udpate don,t refresh list, state persists in Pinia while on page and gets loaded from db upon mount
    // =========================================

    async fetchClosedIssues(projectId: string) {
      const userStore = useUserStore()
      if (userStore.getToken) {
        await eventService.getAllClosedIssues(userStore.getToken, projectId)
          .then((response) => {
            this.Closed = response.data
          }).catch((error) => {
            if (axios.isAxiosError(error)) {
              if (error.response) {
                console.log(error.response?.data)
                console.log(error.response.status)
                console.log(error.response.headers)
              }
              else if (error.request) {
                console.log(error.request)
              }
              else {
                console.log('Error', error.message)
              }
            }
          })
      }
    },

    // =========================================
    // ===========   UPDATE OPEN ISSUES  ===============
    // only udpate don,t refresh list, state persists in Pinia while on page and gets loaded from db upon mount
    // =========================================

    async updateAllOpenIssues(openIssues: Issue[]) {
      const userStore = useUserStore()
      if (userStore.getToken) {
        await eventService.updateAllOpenIssues(userStore.getToken, openIssues, openIssues[0].projectId)
          .then((response) => {
            console.log(response.status)
            if (response.status === 200) console.log('approved boy')
          }).catch((error) => {
            if (axios.isAxiosError(error)) {
              if (error.response) {
                console.log(error.response?.data)
                console.log(error.response.status)
                console.log(error.response.headers)
              }
              else if (error.request) {
                console.log(error.request)
              }
              else {
                console.log('Error', error.message)
              }
            }
          })
      }
    },

    // =========================================
    // ===========   UPDATE ISSUES INPROGRESS  ===============
    // =========================================

    async updateAllIssuesInProgress(issues: Issue[]) {
      const userStore = useUserStore()
      if (userStore.getToken) {
        await eventService.updateIssuesInProgress(userStore.getToken, issues, issues[0].projectId)
          .then((response) => {
            console.log(response.status)
            if (response.status === 200) console.log('approved boy')
          }).catch((error) => {
            if (axios.isAxiosError(error)) {
              if (error.response) {
                console.log(error.response?.data)
                console.log(error.response.status)
                console.log(error.response.headers)
              }
              else if (error.request) {
                console.log(error.request)
              }
              else {
                console.log('Error', error.message)
              }
            }
          })
      }
    },

    // =========================================
    // ===========   UPDATE TO BE TESTED  ===============
    // =========================================

    async updateAllIssuesInReview(issues: Issue[]) {
      const userStore = useUserStore()
      if (userStore.getToken) {
        await eventService.updateAllIssuesInReview(userStore.getToken, issues, issues[0].projectId)
          .then((response) => {
            if (response.status === 200) console.log('approved boy')
          }).catch((error) => {
            if (axios.isAxiosError(error)) {
              if (error.response) {
                console.log(error.response?.data)
                console.log(error.response.status)
                console.log(error.response.headers)
              }
              else if (error.request) {
                console.log(error.request)
              }
              else {
                console.log('Error', error.message)
              }
            }
          })
      }
    },
    // =========================================
    // ===========   UPDATE CLOSED ISSUES  ===============
    // =========================================

    async updateAllClosedIssues(issues: Issue[]) {
      const userStore = useUserStore()
      if (userStore.getToken) {
        await eventService.updateAllClosedIssues(userStore.getToken, issues, issues[0].projectId)
          .then((response) => {
            if (response.status === 200) console.log('approved boy')
          }).catch((error) => {
            if (axios.isAxiosError(error)) {
              if (error.response) {
                console.log(error.response?.data)
                console.log(error.response.status)
                console.log(error.response.headers)
              }
              else if (error.request) {
                console.log(error.request)
              }
              else {
                console.log('Error', error.message)
              }
            }
          })
      }
    },

  },

  getters: {
    getOpenIssues: (state: State) => state.OpenIssues,
    getIssuesInProgress: (state: State) => state.InProgress,
    getReview: (state: State) => state.Review,
    getClosed: (state: State) => state.Closed,
    getProjects: (state: State) => state.Projects,
    getLoadedProjectId: (state: State) => state.LoadedProjectId,
    getFocussedIssue: (state: State) => state.FocusedIssue,
    getShowfocusedIssue: (state: State) => state.ShowFocusedIssue,

  },
})

if (import.meta.hot)
  import.meta.hot.accept(acceptHMRUpdate(useProjectStore, import.meta.hot))
