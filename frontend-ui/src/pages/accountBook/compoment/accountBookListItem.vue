<template>
    <view>
        <uni-card class="accountbook-list-item">
            <uni-title type="h1" :title="title"></uni-title>
            <uni-row>
                <uni-col span="8">
                    <uni-tag :text="'收入：'+income" type="success" :circle="true"></uni-tag>
                </uni-col>
                <uni-col span="8">
                    <uni-tag :text="'支出：'+spending" type="error" :circle="true"></uni-tag>
                </uni-col>
                <uni-col span="8">
                    <uni-tag :text="'收支差：'+profit" type="warning" :circle="true"></uni-tag>
                </uni-col>
            </uni-row>
        </uni-card>
    </view>
</template>

<script setup lang="ts">
import { defineProps, computed } from 'vue';

const profit = computed(() => {
    return props.income - props.spending;
});

const props = defineProps({
    title: {
        type: String,
        default: '名称',
    },
    income: {
        type: Number,
        default: 0,
    },
    spending: {
        type: Number,
        default: 0,
    },
});
</script>

<style lang="scss">
</style>