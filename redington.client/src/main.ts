import './assets/main.css'
import { createApp } from 'vue'
import PrimeVue from 'primevue/config'
import SelectButton from 'primevue/selectbutton'
import 'primevue/resources/themes/lara-light-green/theme.css'
import App from './App.vue'

const app = createApp(App);
app.use(PrimeVue);
app.component('SelectButton', SelectButton);
app.mount('#app');
