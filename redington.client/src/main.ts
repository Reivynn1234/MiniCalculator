import './assets/main.css'
import { createApp } from 'vue'
import PrimeVue from 'primevue/config'
import SelectButton from 'primevue/selectbutton'
import Card from 'primevue/card';
import App from './App.vue'
import InputText from 'primevue/inputtext';
import Dialog from 'primevue/dialog';
import Button from 'primevue/button';

import 'primevue/resources/themes/lara-light-green/theme.css'

const app = createApp(App);
app.use(PrimeVue);
app.component('SelectButton', SelectButton);
app.component('Card', Card);
app.component('InputText', InputText);
app.component('Button', Button);
app.component('Dialog', Dialog);
app.mount('#app');
