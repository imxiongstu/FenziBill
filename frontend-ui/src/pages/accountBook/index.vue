<template>
    <view>
        <!-- 账本列表 -->
        <accountBookListItem v-for="item in accountBookList" :key="item['id']" :name="item['name']" :remark="item['remark']" @click="handleClickAccountBook(item['id'])" />
        <!-- 账本表单弹出层 -->
        <uni-popup ref="createRelationDialog" type="top" @change="handlePopupChange">
            <uni-card>
                <uni-forms :modelValue="form" label-position="top">
                    <uni-forms-item label="账本名称">
                        <uni-easyinput v-model="form.name" placeholder="请输入账本名称"></uni-easyinput>
                    </uni-forms-item>
                    <uni-forms-item label="备注">
                        <uni-easyinput type="textarea" v-model="form.remark" placeholder="备注内容"></uni-easyinput>
                    </uni-forms-item>
                </uni-forms>
                <button type="primary" @click="handleCreateSubmit">创建</button>
            </uni-card>
        </uni-popup>

        <!-- 悬浮按钮 -->
        <uni-fab horizontal="right" vertical="bottom" @fabClick="handleCreate"></uni-fab>
    </view>
</template>

<script setup lang="ts">
import { ApiHub } from '@/common/api-hub';
import { onShow } from '@dcloudio/uni-app';
import { ref } from 'vue';
import accountBookListItem from './compoment/accountBookListItem.vue';

const createRelationDialog = ref();

const defaultForm = { name: '', remark: '' };

const form = ref(Object.assign({}, defaultForm));

const accountBookList = ref([]);

onShow(() => {
    getAccountBookList();
});

/**
 * @description: 获取账本列表
 * @param {*}
 * @return {*}
 */
const getAccountBookList = () => {
    ApiHub.getAllAccountBook().then((res) => {
        accountBookList.value = res.items;
    });
};

/**
 * @description:点击创建按钮
 * @param {*}
 * @return {*}
 */
const handleCreate = () => {
    createRelationDialog.value.open();
};

/**
 * @description: 创建表单提交
 * @param {*}
 * @return {*}
 */
const handleCreateSubmit = () => {
    ApiHub.createAccountBook(form.value).then(() => {
        uni.showToast({
            title: '创建成功',
            icon: 'none',
            duration: 1000,
        });
        createRelationDialog.value.close();
        getAccountBookList();
    });
};

/**
 * @description:处理弹窗状态
 * @param {*} e
 * @return {*}
 */
const handlePopupChange = (e: any) => {
    form.value = Object.assign({}, defaultForm);
};

/**
 * @description: 处理点击账本
 * @param {*} id
 * @return {*}
 */
const handleClickAccountBook = (id: string) => {
    console.log(id);
};
</script>

<style lang="scss">
</style>