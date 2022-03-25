
export interface LoginUserInterface {
  email: string
  password: string
}

export interface RegisterUserInterface {
  userName: string
  email: string
  password: string
}

export interface NewMessageInterface {
  Title: string
  Body: string
}

export interface Issue {
  id: string
  title: string
  description: string
  localDate: string
  type: string
  urgency: string
  projectId: string
  date: string
}
export interface Project {
  projectId: string

  title: string

}
