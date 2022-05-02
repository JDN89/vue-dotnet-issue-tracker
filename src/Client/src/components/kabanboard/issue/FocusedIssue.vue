<script setup lang="ts">

import { useAlertStore } from '~/stores/alertStore'
import { useProjectStore } from '~/stores/projects'

const store = useProjectStore()

const alertStore = useAlertStore();
// ============ URGENCY =======================
// --style--
const myUrgencyStyles = new Map<string, string>([['Medium', 'border-1'], ['Low', 'border-dotted dark:border-dotted'], ['High', 'border-2 dark:border-2 ']])

const urgencyStyle = computed(() => {
    return myUrgencyStyles.get(store.getFocussedIssue!.urgency)!
})

// -- options--
const urgencyOptions = ['LOW', 'MEDIUM', 'HIGH']
const urgencyOptionsHidden = ref(true)
const showUrgencyOptions = () => {
    urgencyOptionsHidden.value = false
}

//--update logic--
const updateUrgency = (urgency: string) => {
    store.getFocussedIssue!.urgency = urgency
    urgencyOptionsHidden.value = true
}

// ==================== ISSUE TYPE ===================
const IssueTypes = ['Design', 'Backend', 'Feature Request', 'QA']
const issueTypesHidden = ref(true)
const showFeatureTypes = () => {
    issueTypesHidden.value = false
}
const updateType = (type: string) => {
    store.FocusedIssue!.type = type
    issueTypesHidden.value = true
}

// ==================== EDIT ISSUE  ===================
const editButtonHidden = ref<boolean>(false)
const editFieldsHidden = ref<boolean>(true)
const editting = async (item: string) => {
    switch (item) {
        case 'Edit':
            editFieldsHidden.value = false
            editButtonHidden.value = true
            break
        case 'Delete':
            if (store.getFocussedIssue) await store.deleteIssue(store.getFocussedIssue)
            store.ShowFocusedIssue = false
            break
    }
}

const uploadEdditedIssue = () => {

    if (store.getFocussedIssue)
        if (store.getFocussedIssue.title.length < 4) {

            alertStore.showAlert = true
            return alertStore.alertMessage = 'Please give your Issue a title of at least 4 characters!'
        }
        else if (store.getFocussedIssue.title.length > 80) {

            alertStore.showAlert = true
            return alertStore.alertMessage = 'The title of your issue is longer then 80 characters, please reduce the length.'
        }
        else if (store.getFocussedIssue.description.length > 1000) {

            alertStore.showAlert = true
            return alertStore.alertMessage = 'The description of your issue is to long, please reduce the length'
        }
        else if (store.getFocussedIssue.description.length < 8) {

            alertStore.showAlert = true
            return alertStore.alertMessage = 'Please give your Issue a description of at least 8 characters!'
        }
        else {

            editFieldsHidden.value = true
            store.ShowFocusedIssue = false
            return store.updateIssue(store.getFocussedIssue)
        }
}
</script>

<template>
    <div class="flex bg-light-300 bg-gray-700 bg-opacity-50 fixed left-0 right-0 bottom-0 top-0 items-center">
        <div class="min-h-44 min-w-lg w-auto max-h-auto w-full m-1 p-2 sm:max-w-70 content-center sm:mx-auto mx-auto">
            <div class="square-border dark:bg-dark-500 p-3 bg-light-500" :class="`${urgencyStyle}`">
                <div class="flex justify-between m-3">
                    <EditButton v-if="!editButtonHidden" class="relative" @edit="editting" />
                    <i v-else i-carbon-fetch-upload-cloud @click="uploadEdditedIssue" />
                    <div>
                        <p v-if="editFieldsHidden" class="overflow-hidden font-semibold font-sans w-86 text-sm">
                            {{ store.getFocussedIssue!.title }}
                        </p>
                        <input v-else v-model="store.getFocussedIssue!.title" type="text" class="bg-transparent"
                            placeholder="Update title minimum 4 characters">
                    </div>

                    <i i-carbon-close class="cursor-pointer" @click="store.ShowFocusedIssue = false" />
                </div>

                <div class="flex mx-auto justify-between items-center">
                    <p v-if="editFieldsHidden" class="m-2">
                        {{ store.getFocussedIssue!.description }}
                    </p>
                    <textarea v-else v-model="store.getFocussedIssue!.description"
                        class="min-h-lg h-auto min-w-full overflow-auto bg-transparent"
                        placeholder="Update description of issue min 8 characters" />
                </div>
                <div class="flex m-1 justify-around space items-center">
                    <span class="ml-2 text-sm text-gray-600 dark:text-gray-300">{{ store.getFocussedIssue!.date
                    }}</span>
                    <div v-if="issueTypesHidden" class="flex justify-around">
                        <Badge :type="store.getFocussedIssue!.type">
                            {{ store.getFocussedIssue!.type }}
                        </Badge>
                        <button v-if="!editFieldsHidden" i-bx-dots-vertical-rounded @click="showFeatureTypes" />
                    </div>
                    <div v-else>
                        <ul class="flex flex-col">
                            <li v-for="(type, index) in IssueTypes" :key="index"
                                class="min-w-10 max-w-39 btn m-1 float-right" @click="updateType(type)">
                                {{ type }}
                            </li>
                        </ul>
                    </div>

                    <div v-if="urgencyOptionsHidden" class="flex justify-around">
                        <Urgency urgency="store.getFocussedIssue!.urgency">
                            {{ store.getFocussedIssue!.urgency.toUpperCase() }}
                        </Urgency>

                        <button v-if="!editFieldsHidden" i-bx-dots-vertical-rounded @click="showUrgencyOptions" />
                    </div>
                    <div v-else>
                        <ul class="flex flex-col">
                            <li v-for="(urgency, index) in urgencyOptions" :key="index"
                                class="min-w-10 max-w-21 btn m-1 float-right" @click="updateUrgency(urgency)">
                                {{ urgency }}
                            </li>
                        </ul>
                    </div>

                    <span />
                </div>
            </div>
        </div>

        <Alert v-if="alertStore.getShowAlert" />
    </div>
</template>
