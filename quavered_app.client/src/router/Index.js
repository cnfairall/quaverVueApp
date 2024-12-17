import { createWebHistory, createRouter } from "vue-router";
import HomePage from "../components/HomePage.vue";
import DetailsPage from "../components/Details.vue";

const routes = [
  {
    path: "/",
    name: "Home",
    component: HomePage,
  },
  {
    path: "/details/:id",
    name: "Details",
    component: DetailsPage,
    props: true,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
