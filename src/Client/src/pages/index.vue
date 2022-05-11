<script setup lang="ts">

</script>

<template>
    <header-guest class="mb-8" />
    <div class="flex mx-auto">
        <div class="m-auto content-center justify-center max-w-xl">

            <h1 class="text-4xl p-3 text-left ">
                About
            </h1>
            <p class="p-3 text-left">

                This is a Project I made to practice Clean Architecture (Robert C. Martin )
                <br>and thin MVC Controllers using the MediatR package with ASP.NET Core 6.0
                <br>
                <br>
                Inspired by the drag and drop functionality of the Notion web app which I tried to incorporate into this
                project.

            </p>

            <h1 class="text-4xl p-3 text-left pt-8">Usage</h1>
            <p class=" p-3 text-left">
                Create an account(fake email must:w
                include @ and .com) or use the test account (jan@test.com - Pa$$w0rd),
                login and create a project to
                track
                bugs and feature requests during the
                projects
                development.
            </p>

        </div>
    </div>

</template>


<style scoped>
li {
    text-align: left;
}

li::before {
    background-color: dark;
}
</style>
