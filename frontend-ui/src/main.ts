import { createSSRApp } from "vue";
import App from "./App.vue";
import store from "@/store/index"

import { request } from "./common/request";

export function createApp() {
  const app = createSSRApp(App);
  app.use(store);

  return {
    app,
  };
}
