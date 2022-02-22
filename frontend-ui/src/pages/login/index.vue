<template>
    <view>
        <view class="logo-box">
            <!-- LOGO部分 -->
            <text class="logo-box-text">LOGO</text>
        </view>
        <view class="form-box">
            <!-- 表单部分 -->
            <uni-forms @submit="handleFormSubmit">
                <uni-forms-item>
                    <uni-easyinput :inputBorder="false" class="form-box-input" placeholder="请输入用户名"></uni-easyinput>
                </uni-forms-item>
                <uni-forms-item>
                    <uni-easyinput type="password" :inputBorder="false" class="form-box-input" placeholder="请输入密码"></uni-easyinput>
                </uni-forms-item>
                <navigator class="form-box-forgetpwd">忘记密码？</navigator>
                <button class="form-box-submit uni-shadow-base" form-type="submit">登陆</button>
                <navigator class="form-box-register">还没有账号？点击注册</navigator>
            </uni-forms>
        </view>
    </view>
</template>

<script setup lang="ts">
const handleFormSubmit = (e: any) => {
    console.log('form submit');
};
</script>

<style lang="scss">
.logo-box {
    height: 20vh;
    background: linear-gradient(
        to right,
        rgb(189, 103, 206),
        rgb(214, 117, 182)
    );
    border-radius: 10px;
    margin: 60px;
    text-align: center;

    .logo-box-text {
        color: white;
        font-size: 60rpx;
        font-weight: bold;
        line-height: 20vh;
    }
}

.form-box {
    margin: 60px;

    .form-box-submit {
        border-radius: 25px;
        background-color: #fb7299;
        color: white;
    }

    .form-box-input {
        border-radius: 25px;
        background-color: #ece3e9;
    }

    .form-box-forgetpwd {
        color: #ada6ab;
        font-size: 12rpx;
        margin-bottom: 20px;
        text-align: center;
    }

    .form-box-register {
        color: #ada6ab;
        font-size: 12rpx;
        margin-top: 20px;
        text-align: center;
    }
}
</style>