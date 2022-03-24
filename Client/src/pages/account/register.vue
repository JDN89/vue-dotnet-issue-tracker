<script setup lang="ts">
import { ErrorMessage, Field, useForm } from 'vee-validate'
import * as yup from 'yup'
import { useUserStore } from '~/stores/users'

const userStore = useUserStore()

// Create a form context with the validation schema

const schema = yup.object({
  email: yup.string().required().email(),
  userName: yup.string().required().min(4),
  password: yup.string().required().min(8).matches(/^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})/,
    'Must Contain 8 Characters, One Uppercase, One Lowercase, One Number and One Special Case Character'),
  confirmPassword: yup
    .string()
    .oneOf([yup.ref('password'), null], 'Confirmed password doesn\'t match')
    .required(),
})

//  IsSubmitting disables the submit button until the yup rules are met

const { handleSubmit, values } = useForm({
  validationSchema: schema,
})

// Sync store state with vee-validate state
// store formData(email,password) in createdUserData
// This is a one way binding
watch(values, (newFormData) => {
  userStore.$patch({ userRegistrationData: newFormData })
})

// create a handler to submit the store state
// the store action will only run when the user submits valid form data
const onSubmit = handleSubmit(userStore.registerUser)

// Upon successful registration, reroute to login page after 2 seconds
const router = useRouter()
onUpdated(() => {
  if (userStore.getRegistrationFormIsVisible === false) {
    setTimeout(() => {
      router.push({
        name: 'acount/login',
      })
    }, 2000)
  }
})
</script>

<template>
  <HeaderGuest />
  <div class="mx-auto min-w-xs max-w-xs py-6 prose">
    <h2 class>
      Register
    </h2>

    <form
      v-if="userStore.getRegistrationFormIsVisible"
      class="flex flex-col"
      @submit="onSubmit"
    >
      <div class="flex flex-col">
        <div i-carbon-email class="mt-3 ml-4.5 absolute" />
        <Field name="email" type="email" placeholder="Email" class="field" />

        <ErrorMessage name="email" class="errorMessage" />
      </div>

      <div class="flex flex-col">
        <div i-carbon-user-data class="mt-3 ml-4.5 absolute" />
        <Field name="userName" type="string" placeholder="userName" class="field" />

        <ErrorMessage name="userName" class="errorMessage" />
      </div>

      <div class="flex flex-col">
        <div i-carbon-password class="mt-3 ml-4.5 absolute" />
        <Field
          name="password"
          type="password"
          placeholder="Password"
          class="field"
        />
        <ErrorMessage name="password" class="errorMessage" />
      </div>

      <div class="flex flex-col">
        <div i-carbon-password class="mt-3 ml-4.5 absolute" />
        <Field
          name="confirmPassword"
          type="password"
          placeholder="Confirm Password"
          class="field"
        />
        <ErrorMessage name="confirmPassword" class="errorMessage" />
      </div>

      <button
        type="submit"
        class=" hover btn mt-2 hover w-21 bg-teal-800 dark:bg-teal-700 dark:text-light-50 rounded-2xl mx-auto"
      >
        Submit
      </button>
    </form>
    <p
      v-else
      to="login"
      w:text="center 2xl  yellow-300 dark:light-50"
      w:bg="red-900 dark:teal-700"
      class="font-bold rounded-2xl text-yellow-300 mx-auto mx-1"
    >
      Registration successful!
    </p>
  </div>
</template>

<style scoped>
input{ padding-left: 48px;

}
</style>
