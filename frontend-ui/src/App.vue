<script setup lang="ts">
import { onLaunch, onShow, onHide } from '@dcloudio/uni-app';
import { useRequestInterceptor } from './common/request';
import { checkLogin } from './common/auth';

onLaunch(() => {
    //启用拦截器
    useRequestInterceptor();
    //登录状态检查
    checkLogin();
});
onShow(() => {});
onHide(() => {});
</script>

<style lang="scss">
@import '@dcloudio/uni-ui/lib/uni-scss';
</style>
