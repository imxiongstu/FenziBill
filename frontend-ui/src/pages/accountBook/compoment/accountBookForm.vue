<template>
    <view>
        <uni-card class="form-box">
            <view>
                <button type="primary">fade</button>
                <uni-transition mode-class="fade" :styles="{'width':'100px','height':'100px','backgroundColor':'red'}" :show="show" @change="change" />
            </view>
        </uni-card>
    </view>
</template>

<script setup lang="ts">
</script>

<style lang="scss">
.form-box {
    height: 80vh;
}
</style>