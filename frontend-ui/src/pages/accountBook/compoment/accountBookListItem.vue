<template>
    <view>
        <uni-card class="accountbook-list-item" :title="name" extra="312">
            <template v-slot:title>
                <text>f</text>
            </template>
            <text class="uni-secondary-color">{{remark}}</text>
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
    name: {
        type: String,
        default: '名称',
    },
    remark: {
        type: String,
        default: '备注',
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
.accountbook-list-item:hover {
    background-color: #f5f5f5;
    transform: scale(1.05);
}
</style>