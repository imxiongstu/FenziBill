import { defineConfig } from "vite";
import uni from "@dcloudio/vite-plugin-uni";
import path = require("path");

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [uni()],
});
