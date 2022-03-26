import axios from 'axios'
import type { Issue, LoginUserInterface, RegisterUserInterface } from '../types/interfaces'

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
  async addNewProject(token: string, title: string) {
    return await apiClient.post(`project/${title}`, null, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },

  // =================ISSUE REQUEST ===================
  async getAllOpenIssues(token: string, projectId: string) {
    return await apiClient.get(`openissue/${projectId}`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },
  async updateAllOpenIssues(token: string, openIssues: Issue[], projectId: string) {
    return await apiClient.put(`openissue/${projectId}`, openIssues, {
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
    return await apiClient.put(`issuesInReview/${projectId}`, closedIssues, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  },
  // async retrieveSession(token: string) {
  //   return await apiClient.post('account/retrieveSession', token)
  // },
}
