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
export interface FocusedIssue {
  id: string
  title: string
  progress: string
  description: string
  date: string
  type: string
  urgency: string
}
export interface Project {
  projectId: string

  title: string

}
export interface UpdateProject {
  projectId: string|null

  title: string|null

}
export interface AddProject {
  title: string|null
}
