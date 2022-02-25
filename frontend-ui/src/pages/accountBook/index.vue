<template>
    <view>
        <accountBookListItem />
        <accountBookFormVue />
        <!-- 悬浮按钮 -->
        <uni-fab horizontal="right" vertical="bottom" @fabClick="handleCreate"></uni-fab>
    </view>
</template>

<script setup lang="ts">
import accountBookListItem from './compoment/accountBookListItem.vue';
import accountBookFormVue from './compoment/accountBookForm.vue';

const handleCreate = () => {};
</script>

<style lang="scss">
</style>