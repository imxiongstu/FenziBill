<template>
    <view>
        <!-- 列表盒子 -->
        <view class="relation-box uni-shadow-sm">
            <uni-list>
                <uni-list-item :title="item.name" v-for="item in relationList" :key="item.id" :show-badge="true" badge-text="0" :thumb="thumb" thumb-size="sm"></uni-list-item>
            </uni-list>
        </view>
        <uni-fab horizontal="right" vertical="bottom" :direction="direction" @fabClick="handleCreate"></uni-fab>
        <!-- 添加关系弹窗 -->
        <uni-popup ref="popup" type="center">
            <uni-popup-dialog mode="input" title="新建" placeholder="请输入关系名（例：朋友）" @confirm="handleCreateDialogConfirm"></uni-popup-dialog>
        </uni-popup>
    </view>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { ApiHub } from '@/common/api-hub';
import { onShow } from '@dcloudio/uni-app';
import thumb from '/static/icon/relation_thumb.png';

const popup = ref();

const relationList = ref([]);

//页面重新显示事件
onShow(() => {
    getRelationList();
});

//点击创建按钮
const handleCreate = () => {
    popup.value.open();
};

//获取关系列表
const getRelationList = () => {
    ApiHub.getAllRelation().then((res) => {
        relationList.value = res.items;
    });
};

//处理创建Dialog确认
const handleCreateDialogConfirm = (e: any) => {
    //创建关系
    ApiHub.createRelation(e).then((res) => {
        getRelationList();
        uni.showToast({
            title: '创建成功',
            icon: 'none',
            duration: 1000,
        });
    });

    popup.value.close();
};
</script>

<style lang="scss">
.relation-box {
    margin: 20px;
}
</style>