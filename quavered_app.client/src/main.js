import './assets/bootstrap/bootstrap.min.css'
import './assets/bootstrap/bootstrap.min.js'
import './assets/bootstrap/bootstrap-grid.css'
import './assets/bootstrap/bootstrap-reboot.css'
import './assets/bootstrap/bootstrap-utilities.css'

import { createApp } from 'vue';
import App from './App.vue';
import router from './router/Index';

createApp(App).use(router).mount('#app')
