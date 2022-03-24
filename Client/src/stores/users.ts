// @ts-check
import { acceptHMRUpdate, defineStore } from 'pinia'
import axios from 'axios'
import type { LoginUserInterface, RegisterUserInterface } from '~/types/interfaces'
import eventService from '~/composables/eventService'

interface State {
  registrationFormIsVisible: boolean
  userRegistrationData: RegisterUserInterface | null
  loginData: LoginUserInterface|null
  token: string | null
  username: string|null
}

export const useUserStore = defineStore({
  id: 'user',
  state: (): State => ({
    registrationFormIsVisible: true,
    userRegistrationData: null,
    loginData: null,
    token: null,
    username: null,

  }),

  actions: {

    async registerUser() {
      if (this.userRegistrationData) {
        console.log(this.userRegistrationData)

        await eventService.registerUser(this.userRegistrationData)
          .then(() => {
            this.userRegistrationData = null
            this.registrationFormIsVisible = false
          })
          .catch((error) => {
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
    // ===========   LOGIN  ===============
    // don't return sensitive data, only id
    // =========================================
    async loginUser(user: LoginUserInterface) {
      await eventService.loginUser(user)
        .then((res) => {
          this.token = res.data.token
          this.username = res.data.username

          if (this.token == null) return console.error('no token set')
          window.localStorage.setItem('token', this.token)
          if (this.username == null) return console.error('no username set')
          window.localStorage.setItem('username', this.username)
          this.loginData = null
        })
        .catch((error) => {
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
    },
    // ===================================
    // ===========  RETRIEVE SESSION  ===============
    // ===================================

    // async retrieveSession(token: string) {
    //   await eventService.retrieveSession(token)
    //     .then((res) => {
    //       this.token = res.data.token
    //       this.username = res.data.username

    //       if (this.token == null) return console.error('no token set')
    //       window.localStorage.setItem('token', this.token)
    //       if (this.username == null) return console.error('no username set')
    //       window.localStorage.setItem('username', this.username)
    //       this.loginData = null
    //     })
    //     .catch((error) => {
    //       if (axios.isAxiosError(error)) {
    //         if (error.response) {
    //           console.log(error.response?.data)
    //           console.log(error.response.status)
    //           console.log(error.response.headers)
    //         }
    //         else if (error.request) {
    //           // The request was made but no response was received
    //           // `error.request` is an instance of XMLHttpRequest in the browser and an instance of
    //           // http.ClientRequest in node.js
    //           console.log(error.request)
    //         }
    //         else {
    //           // Something happened in setting up the request that triggered an Error
    //           console.log('Error', error.message)
    //         }
    //       }
    //     })
    // },

    // =========================================
    // ===========   LOGOUT  ===============
    // =========================================
    logout() {
      window.localStorage.removeItem('token')
      window.localStorage.removeItem('username')
    },

  },

  getters: {
    getLoginData: (state: State) => state.loginData,
    getToken: (state: State) => state.token,
    getUsername: (state: State) => state.username,
    getRegistrationFormIsVisible: (state: State) => state.registrationFormIsVisible,
  },
})

if (import.meta.hot)
  import.meta.hot.accept(acceptHMRUpdate(useUserStore, import.meta.hot))
