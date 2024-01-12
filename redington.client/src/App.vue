<template>
    <SelectButton v-model="value" :options="options" aria-labelledby="basic" />
</template>


<script lang="ts">
    import { defineComponent } from "vue";
    import SelectButton from 'primevue/selectbutton'

    interface Data {
        options: string[]
        value: string
    }

    export default defineComponent({
        name: 'App',
        components: {
            SelectButton,
        },
        data(): Data {
            return {
                options: ["Combined With", "Either"],
                value: "Combined With"
            }
        }
    })
</script>

<style lang="scss">
    #app {
        text-align: center;
    }
</style>