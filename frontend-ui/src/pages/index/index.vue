<template>
    <view>
        <view class="statistical-card">
            <text>这是一个基础卡片示例，内容较少，此示例展示了一个没有任何属性不带阴影的卡片。</text>
        </view>
        <view>
            <uni-card class="list-card" :margin="false">
                <uni-segmented-control :current="current" :values="items" @clickItem="onClickItem" styleType="text" activeColor="rgb(0, 122, 255)"></uni-segmented-control>
                <uni-list>
                    <uni-list-item title="列表文字"></uni-list-item>
                    <uni-list-item title="列表文字"></uni-list-item>
                    <uni-list-item title="列表文字"></uni-list-item>
                    <uni-list-item title="列表文字"></uni-list-item>
                    <uni-list-item title="列表文字"></uni-list-item>
                    <uni-list-item title="列表文字"></uni-list-item>
                </uni-list>
            </uni-card>
        </view>
    </view>
</template>

<script setup lang="ts">
import { ref } from 'vue';
const items = ref(['最近', '收入', '支出']);
</script>

<style lang="scss">
.statistical-card {
    height: 200rpx;
    width: 75vw;
    margin: 0 auto;
    margin-top: 50rpx;
    border-radius: 20px 20px 0 0;
    padding: 25px;
    background: linear-gradient(
        to right,
        rgb(96, 97, 96, 0.8),
        rgb(34, 43, 33, 0.8)
    );
    box-shadow: 0 0px 6px 1px rgb(165 165 165 / 50%);
}

.list-card {
    margin: 0 auto;
    border-radius: 20px;
    height: 100vh;
}
</style>
