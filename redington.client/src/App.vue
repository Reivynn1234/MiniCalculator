<template>
    <BlockUI :blocked="loading" fullScreen >
        <span>
            <SelectButton id="selectButton" v-model="type" :options="options" aria-labelledby="basic" />
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
            <Button id="calculate" label="Calculate" @click="calculate" :disabled="!isFormValid" />
        </span>
        <Dialog v-model:visible="visible" modal header="Solution" :style="{ width: '50rem' }" :breakpoints="{ '1199px': '75vw', '575px': '90vw' }">
            <p>
                {{output}}
            </p>
        </Dialog>
    </BlockUI>
</template>


<script lang="ts">
    import { defineComponent } from "vue";
    import SelectButton from 'primevue/selectbutton'
    import Card from 'primevue/card';
    import Button from 'primevue/button';
    import InputText from 'primevue/inputtext';
    import Dialog from 'primevue/dialog';

    interface Data {
        options: string[]
        type: string
        calculation: {}
        a: number
        b: number
        aValid: boolean
        bValid: boolean
        visible: boolean
        output: string
        loading: boolean
    }

    //For the two calculations
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
            Button,
            Dialog
        },
        data(): Data {
            return {
                options: [Calculation.combined_with, Calculation.either],
                type: Calculation.combined_with,
                calculation: Calculation,
                a: 0,
                b: 0,
                aValid: true,
                bValid: true,
                visible: false,
                output: "",
                loading: false,
            }
        },

        //Checking validity of both inputs
        computed: {
            isFormValid(): boolean {
                return this.aValid && this.bValid
            }
        },

        // Pays attention to the validity of P(A) and P(B)
        watch: {
            a() {
                this.aValid = this.a >= 0 && this.a <= 1
            },
            b() {
                this.bValid = this.b >= 0 && this.b <= 1
            }
        },
        methods: {
            async calculate(): Promise<void>{
                this.loading = true
                let result = await this.calculationFetch()
                if (result == -1) {
                    this.output = "Error with the calculation. Please try again."
                } else {
                    this.output = "The calculation resulted in the value in 6 significant figures: " + Number(result.toPrecision(6))
                }
                this.loading = false
                this.visible = true

            },
            async calculationFetch(): Promise<number> {
                try {
                    const response = await fetch('calculation/' + this.type.replace(/ /g, ''), {
                        method: "POST",
                        headers: {
                            "Content-Type": "application/json",
                        },
                        body: JSON.stringify(
                            {
                                a: this.a,
                                b: this.b
                            }
                        )
                    })

                    var status = await response.status;

                    const responseData = await response.json();

                    if (status < 200 || status >= 300) {
                        throw new Error(responseData.msg || "Request failed with status: " + status);
                    }

                    return responseData
                } catch (error) {
                    return -1
                }
            }
        }
    })
</script>

<style lang="scss">
    #app {
        text-align: center;
    }
</style>