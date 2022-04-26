import axios from 'axios'
import type { AddProject, Issue, LoginUserInterface, NewIssue, RegisterUserInterface, UpdateIssue, UpdateProject } from '../types/interfaces'

const apiClient = axios.create({
  baseURL: import.meta.env.VITE_APP_API_URL,
  withCredentials: false,
})

export default {

  // ===========  User Requests  ===============

  async registerUser(user: RegisterUserInterface) {
    return await apiClient.post('account/register', user)
  },
  async loginUser(user: LoginUserInterface) {
    return await apiClient.post('account/login', user)
  },

  // ===========  Project Requests  ===============

  async getAllProjects(token: string) {
    return await apiClient.get('project', {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },
  async addNewProject(token: string, newProject: AddProject) {
    return await apiClient.post('project/', newProject, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },
  async deleteProject(token: string, id: string) {
    return await apiClient.delete(`project/${id}`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },
  async updateProject(token: string, project: UpdateProject) {
    return await apiClient.put('project/', project, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },
  // ================= All PROJECT RELATED ISSUES REQUEST ===================
  async getAllOpenIssues(token: string, projectId: string) {
    return await apiClient.get(`openissues/${projectId}`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },
  async updateAllOpenIssues(token: string, openIssues: Issue[], projectId: string) {
    return await apiClient.put(`openissues/${projectId}`, openIssues, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },
  async getAllIssuesInProgress(token: string, projectId: string) {
    return await apiClient.get(`issuesInProgress/${projectId}`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },
  async updateIssuesInProgress(token: string, inProgressIssues: Issue[], projectId: string) {
    return await apiClient.put(`issuesInProgress/${projectId}`, inProgressIssues, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },
  async getAllReviewIssues(token: string, projectId: string) {
    return await apiClient.get(`issuesInReview/${projectId}`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },
  async updateAllIssuesInReview(token: string, issuesInReview: Issue[], projectId: string) {
    return await apiClient.put(`issuesInReview/${projectId}`, issuesInReview, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },
  async getAllClosedIssues(token: string, projectId: string) {
    return await apiClient.get(`ClosedIssues/${projectId}`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },
  async updateAllClosedIssues(token: string, closedIssues: Issue[], projectId: string) {
    return await apiClient.put(`ClosedIssues/${projectId}`, closedIssues, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },

  // ================= SINGLE ISSUE REQUEST ===================

  async addSingleOpenIssue(token: string, openIssue: NewIssue) {
    return await apiClient.post('OpenIssues', openIssue, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },
  async deleteOpenIssue(token: string, id: string) {
    return await apiClient.delete(`OpenIssues/${id}`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },
  async deleteInprogressIssue(token: string, id: string) {
    return await apiClient.delete(`issuesInProgress/${id}`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },

  async deleteIssueInReview(token: string, id: string) {
    return await apiClient.delete(`issuesInReview/${id}`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },
  async deleteClosedIssue(token: string, id: string) {
    return await apiClient.delete(`ClosedIssues/${id}`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },
  async updateSingleOpenIssue(token: string, newIssue: UpdateIssue) {
    return await apiClient.put('OpenIssues/UpdateSingleOpenIssue', newIssue, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },

  async updateSingleIssueInProgress(token: string, newIssue: UpdateIssue) {
    return await apiClient.put('issuesInProgress/UpdateSingleIssueInProgress', newIssue, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },
  async updateSingleIssueInReview(token: string, newIssue: UpdateIssue) {
    return await apiClient.put('issuesInReview/UpdateSingleIssueInReview', newIssue, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },
  async updateSingleClosedIssue(token: string, newIssue: UpdateIssue) {
    return await apiClient.put('ClosedIssues/UpdateSingleClosedIssue', newIssue, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },
  // async retrieveSession(token: string) {
  //   return await apiClient.post('account/retrieveSession', token)
  // },
}
