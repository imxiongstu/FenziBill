<script setup lang="ts">
import { onLaunch, onShow, onHide } from '@dcloudio/uni-app';
import { useRequestInterceptor } from './common/request';

onLaunch(() => {
    uni.getStorage({
        key: 'FenziBill-Token',
        fail: () => {
            uni.reLaunch({
                url: '/pages/login/index',
            });
        },
    });

    useRequestInterceptor();
});
onShow(() => {});
onHide(() => {});
</script>

<style lang="scss">
@import '@dcloudio/uni-ui/lib/uni-scss';
</style>
