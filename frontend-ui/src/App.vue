<script setup lang="ts">
import { onLaunch, onShow, onHide } from '@dcloudio/uni-app';
import { useRequestInterceptor } from './common/request';

onLaunch(() => {
    useRequestInterceptor();
});
onShow(() => {});
onHide(() => {});
</script>

<style lang="scss">
@import '@dcloudio/uni-ui/lib/uni-scss';
</style>
