import './assets/main.css'
import { createApp } from 'vue'
import PrimeVue from 'primevue/config'
import SelectButton from 'primevue/selectbutton'

import App from './App.vue'

import 'primevue/resources/themes/lara-light-green/theme.css'

const app = createApp(App);
app.use(PrimeVue);
app.component('SelectButton', SelectButton);
app.mount('#app');
