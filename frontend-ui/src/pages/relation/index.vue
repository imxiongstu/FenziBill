<template>
    <view>
        <!-- 列表盒子 -->
        <view class="relation-box uni-shadow-sm">
            <uni-list>
                <uni-swipe-action>
                    <view>
                        <uni-swipe-action-item @click="handleSwipeClick($event,item['id'])" v-for="item in relationList" :key="item['id']" :right-options="leftOptions">
                            <view>
                                <uni-list-item :title="item['name']" :show-badge="true" badge-text="0" :thumb="thumb" thumb-size="sm"></uni-list-item>
                            </view>
                        </uni-swipe-action-item>
                    </view>
                </uni-swipe-action>
            </uni-list>
        </view>
        <uni-fab horizontal="right" vertical="bottom" @fabClick="handleCreate"></uni-fab>
        <!-- 添加关系弹窗 -->
        <uni-popup ref="createRelationDialog" type="center">
            <uni-popup-dialog mode="input" title="新建" placeholder="请输入关系名（例：朋友）" @confirm="handleCreateDialogConfirm"></uni-popup-dialog>
        </uni-popup>
        <!-- 修改关系弹窗 -->
        <uni-popup ref="changeRelationDialog" type="center">
            <uni-popup-dialog mode="input" title="重命名" placeholder="请输入关系名（例：朋友）" @confirm="handleChangeDialogConfirm"></uni-popup-dialog>
        </uni-popup>
    </view>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { ApiHub } from '@/common/api-hub';
import { onShow } from '@dcloudio/uni-app';
import thumb from '/static/icon/relation_thumb.png';

const createRelationDialog = ref();
const changeRelationDialog = ref();

const relationList = ref([]);
const currentRelationId = ref('');

//列表框的左滑按钮选项
const leftOptions = [
    {
        text: '重命名',
        style: {
            backgroundColor: 'rgb(0, 122, 255)',
            color: '#fff',
        },
    },
    {
        text: '删除',
        style: {
            backgroundColor: '#FF4949',
            color: '#fff',
        },
    },
];

//页面重新显示事件
onShow(() => {
    getRelationList();
});

/**
 * @description: 点击创建按钮
 * @param {*}
 * @return {*}
 */
const handleCreate = () => {
    createRelationDialog.value.open();
};

/**
 * @description: 获取关系列表
 * @param {*}
 * @return {*}
 */
const getRelationList = () => {
    ApiHub.getAllRelation().then((res) => {
        relationList.value = res.items;
    });
};

/**
 * @description: 处理创建Dialog确认
 * @param {*}
 * @return {*}
 */
const handleCreateDialogConfirm = (e: any) => {
    //创建关系
    ApiHub.createRelation(e).then((res) => {
        uni.showToast({
            title: '创建成功',
            icon: 'none',
            duration: 1000,
        });
        getRelationList();
    });

    createRelationDialog.value.close();
};

/**
 * @description: 处理修改Dialog确认
 * @param {*} e
 * @return {*}
 */
const handleChangeDialogConfirm = (e: any) => {
    //修改关系名称
    ApiHub.changeRelationName(currentRelationId.value, e).then((res) => {
        uni.showToast({
            title: '修改成功',
            icon: 'none',
            duration: 1000,
        });
        getRelationList();
    });

    changeRelationDialog.value.close();
};

/**
 * @description: 处理列表左滑点击
 * @param {*} e
 * @param {*} id
 * @return {*}
 */
const handleSwipeClick = (e: any, id: string) => {
    switch (e.index) {
        //重命名
        case 0:
            currentRelationId.value = id;
            changeRelationDialog.value.open();
            break;
        //删除
        case 1:
            ApiHub.deleteRelation(id).then((res) => {
                uni.showToast({
                    title: '删除成功',
                    icon: 'none',
                    duration: 1000,
                });
                getRelationList();
            });
            break;
    }
};
</script>

<style lang="scss">
.relation-box {
    margin: 20px;
}
</style>