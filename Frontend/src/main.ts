import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { createHead } from '@vueuse/head'; 
import { createPinia } from 'pinia';
import language from './language'; 

const app = createApp(App);
const head = createHead();
const pinia = createPinia();

app.use(pinia);
app.use(router);
app.use(language);
app.use(head);
app.mount('#app');