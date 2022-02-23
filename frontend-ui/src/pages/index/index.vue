<template>
    <view>
        <uni-card class="statistical-card">
            <text>这是一个基础卡片示例，内容较少，此示例展示了一个没有任何属性不带阴影的卡片。</text>
        </uni-card>
        <view class="list-box">
            <uni-segmented-control :current="current" :values="items" @clickItem="onClickItem" styleType="button" activeColor="rgb(0, 122, 255)"></uni-segmented-control>
            <view class="content">
                <view v-show="current === 0">选项卡1的内容</view>
                <view v-show="current === 1">选项卡2的内容</view>
                <view v-show="current === 2">选项卡3的内容</view>
            </view>
        </view>
    </view>
</template>

<script setup lang="ts">
import { ref } from 'vue';
const items = ref(['最近', '收入', '支出']);
</script>

<style lang="scss">
.statistical-card {
    height: 350rpx;
}
.list-box {
    margin: 30rpx;
}
</style>
