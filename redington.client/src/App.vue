<template>
    <SelectButton v-model="value" :options="options" aria-labelledby="basic" /> 
    <br />
    <Card>
        <template #title>{{value}}</template>
        <template #content>
            <p id="combined" v-if="value==calculation.combined_with">
                Probability of events A and B if independent: P(A)*P(B)
            </p>
            <p id="either" v-else>
                Probability of event A or B occuring: P(A) + P(B) - P(A)*P(B)
            </p>
        </template>
    </Card>
</template>


<script lang="ts">
    import { defineComponent } from "vue";
    import SelectButton from 'primevue/selectbutton'
    import Card from 'primevue/card';

    interface Data {
        options: string[]
        value: string
        calculation: {}
    }

    enum Calculation {
        combined_with = "Combined With",
        either = "Either",
    }

    export default defineComponent({
        name: 'App',
        components: {
            SelectButton,
            Card
        },
        data(): Data {
            return {
                options: [Calculation.combined_with, Calculation.either],
                value: Calculation.combined_with,
                calculation: Calculation
            }
        }
    })
</script>

<style lang="scss">
    #app {
        text-align: center;
    }
</style>