// @ts-check
import { acceptHMRUpdate, defineStore } from 'pinia'
import axios from 'axios'
// import axios from 'axios'
import type { Issue, Project } from '~/types/interfaces'
// import eventService from '~/composables/eventService'

import { useUserStore } from '~/stores/users'
import eventService from '~/composables/eventService'

interface State {
  OpenIssues: Issue [] | null
  InProgress: Issue [] | null
  Review: Issue [] | null
  Closed: Issue[] | null
  Projects: Project []| null

}

export const useProjectStore = defineStore({
  id: 'Projects',
  state: (): State => ({
    Projects: null,
    OpenIssues: null,

    InProgress: null,

    Review: null,

    Closed: null,
  }),

  actions: {

    // =========================================
    // ===========   FETCH Projects  ===============
    // =========================================
    async fetchProjects() {
      const userStore = useUserStore()

      if (userStore.getToken) {
        await eventService.getAllProjects(userStore.getToken)
          .then((response) => {
            this.Projects = response.data
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
      console.log(openIssues)
      return console.log('fire')
    },

    // =========================================
    // ===========   UPDATE ISSUES INPROGRESS  ===============
    // only udpate don,t refresh list, state persists in Pinia while on page and gets loaded from db upon mount
    // =========================================

    async updateAllIssuesInProgress(issues: Issue[]) {
      console.log('in progress')

      console.log(issues)
    },

    // =========================================
    // ===========   UPDATE TO BE TESTED  ===============
    // only udpate don,t refresh list, state persists in Pinia while on page and gets loaded from db upon mount
    // =========================================

    async updateAllIssuesToBeTested(issues: Issue[]) {
      console.log('review')

      console.log(issues)
    },
    // =========================================
    // ===========   UPDATE CLOSED ISSUES  ===============
    // only udpate don,t refresh list, state persists in Pinia while on page and gets loaded from db upon mount
    // =========================================

    async updateAllClosedIssues(issues: Issue[]) {
      console.log('closed')

      console.log(issues)
    },

  },

  getters: {
    getOpenIssues: (state: State) => state.OpenIssues,
    getIssuesInProgress: (state: State) => state.InProgress,
    getReview: (state: State) => state.Review,
    getClosed: (state: State) => state.Closed,
    getProjects: (state: State) => state.Projects,

  },
})

if (import.meta.hot)
  import.meta.hot.accept(acceptHMRUpdate(useProjectStore, import.meta.hot))
