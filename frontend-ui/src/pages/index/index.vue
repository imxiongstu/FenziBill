<template>
    <view>
        <uni-card class="statistical-card">
            <text>这是一个基础卡片示例，内容较少，此示例展示了一个没有任何属性不带阴影的卡片。</text>
        </uni-card>
        <button type="primary" @click="handleClick">发送请求</button>
    </view>
</template>

<script setup lang="ts">
import { ApiHub } from '@/common/api-hub';
import { useStore } from 'vuex';

const store = useStore();

const handleClick = () => {
    store.dispatch('user/getUserInfo').then((res) => {
        console.log(res);
    });
};
</script>

<style lang="scss">
.statistical-card {
    height: 350rpx;
}
</style>
