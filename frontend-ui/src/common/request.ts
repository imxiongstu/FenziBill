export function request(url: string, method: UniApp.RequestOptions["method"]) {
    uni.request({
        url: url,
        method: method,
        data: {
            text: 'uni.request'
        },
        header: {
            'custom-header': 'hello' //自定义请求头信息
        },
        success: (res) => {
            console.log(res.data);
        }
    });
}