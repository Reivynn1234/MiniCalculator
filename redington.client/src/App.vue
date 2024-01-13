<template>
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
        <Button id="calculate" label="Calculate" @click="calculate" :disabled="!isFormValid"/>
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
        aValid: boolean
        bValid: boolean
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
            Button
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
            async calculate(): Promise<void> {
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

                    console.log("Success:", response);
                    console.log(responseData)
                } catch (error) {
                    console.error("Error:", error);
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