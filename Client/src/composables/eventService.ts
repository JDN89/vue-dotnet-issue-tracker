import axios from 'axios'
import type { LoginUserInterface, RegisterUserInterface } from '../types/interfaces'

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

  async getAllOpenIssues(token: string, projectId: string) {
    return await apiClient.get(`openissue/${projectId}`, {
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
  async getAllReviewIssues(token: string, projectId: string) {
    return await apiClient.get(`testissue/${projectId}`, {
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
  // async retrieveSession(token: string) {
  //   return await apiClient.post('account/retrieveSession', token)
  // },
}
