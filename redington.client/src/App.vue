<template>
    <span>
        <SelectButton v-model="type" :options="options" aria-labelledby="basic" />
        <br />
        <Card>
            <template #title>
                {{type}}
            </template>
            <template #content>
                <p id="combined" v-if="type==calculation.combined_with">
                    Probability of events A and B if independent: P(A)*P(B)
                </p>
                <p id="either" v-else>
                    Probability of event A or B occuring: P(A) + P(B) - P(A)*P(B)
                </p>
                <br />
                <div>P(A)<InputText id="a" v-model="a" /></div>
                <br />
                <div>P(B)<InputText id="b" v-model="b" /></div>
            </template>
        </Card>
        <br />
        <Button label="Calculate" @click="calculate"/>
    </span>
</template>


<script lang="ts">
    import { defineComponent } from "vue";
    import SelectButton from 'primevue/selectbutton'
    import Card from 'primevue/card';
    import Button from 'primevue/button';
    import InputText from 'primevue/inputtext';

    interface Data {
        options: string[]
        type: string
        calculation: {}
        a: number
        b: number
    }

    enum Calculation {
        combined_with = "Combined With",
        either = "Either",
    }

    export default defineComponent({
        name: 'App',
        components: {
            SelectButton,
            Card,
            InputText,
            Button
        },
        data(): Data {
            return {
                options: [Calculation.combined_with, Calculation.either],
                type: Calculation.combined_with,
                calculation: Calculation,
                a: 0,
                b: 0
            }
        },
        methods: {
            calculate(): void {
                console.log("pressed")
            }
        }
    })
</script>

<style lang="scss">
    #app {
        text-align: center;
    }
</style>