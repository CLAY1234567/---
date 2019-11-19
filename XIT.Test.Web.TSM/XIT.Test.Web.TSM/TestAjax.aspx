<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestAjax.aspx.cs" Inherits="HPIT.Logistic.PM.WebApp.TestAjax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="jquery-1.7.2.min.js"></script>
    <script src="../plugins/jQuery/jquery-2.2.3.min.js"></script>
    <script src="Echarts.js"></script>
    <style>
        #loading {
            display: none;
            width: 100%;
            height: 100%;
            opacity: 0.4;
            filter: alpha(opacity=40);
            background: while;
            position: absolute;
            top: 0;
            left: 0;
            z-index: 2000;
        }
    </style>
</head>
<body>
    <input id="zhu" type="button" value="绘制柱状图" />
    <input id="bing" type="button" value="绘制饼状图" />
    <input id="zhe" type="button" value="绘制折线图" />
    <input id="zhefuza" type="button" value="绘制复杂折线图" />
    <div id="main" style="width: 600px; height: 400px;"></div>
    <div>
        <div id="loading">
            <img src="img/loading.gif" style="margin-left: 40%; margin-top: 200px; width: 150px; height: 150px;" />
        </div>
        <input id="Button1" type="button" value="获取json" />
        <input id="Button2" type="button" value="获取js" />
        <input id="Button3" type="button" value="获取后台服务数据" />
        <input id="Button4" type="button" value="获取后台Json服务数据" />
        <input id="Button5" type="button" value="getJson获取后台Json服务数据" />
        <textarea id="TextArea1" cols="40" rows="5"></textarea>
    </div>
    <script charset="utf-8">
        $(document).ready(function () {
            $("#zhu").click(function () {
                // 基于准备好的dom，初始化echarts实例
                var myChart = echarts.init(document.getElementById('main'));

                // 指定图表的配置项和数据
                var option = {
                    title: {
                        text: 'ECharts 入门示例'
                    },
                    tooltip: {},
                    legend: {
                        data: ['销量']
                    },
                    xAxis: {
                        data: ["衬衫", "羊毛衫", "雪纺衫", "裤子", "高跟鞋", "袜子"]
                    },
                    yAxis: {},
                    series: [{
                        name: '销量',
                        type: 'bar',
                        data: [5, 20, 36, 10, 10, 20]
                    }]
                };
                //option = {
                //    xAxis: {
                //        type: 'category',
                //        data: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun']
                //    },
                //    yAxis: {
                //        type: 'value'
                //    },
                //    series: [{
                //        data: [120, 200, 150, 80, 70, 110, 130],
                //        type: 'bar'
                //    }]
                //};
                // 使用刚指定的配置项和数据显示图表。
                myChart.setOption(option);
            });
            $("#bing").click(function () {
                var myChart = echarts.init(document.getElementById('main'));
                myChart.setOption({
                    series: [
                        {
                            name: '访问来源',
                            type: 'pie',
                            radius: '55%',
                            data: [
                                { value: 235, name: '视频广告' },
                                { value: 274, name: '联盟广告' },
                                { value: 310, name: '邮件营销' },
                                { value: 335, name: '直接访问' },
                                { value: 400, name: '搜索引擎' }
                            ]
                        }
                    ]
                })
            });
            $("#zhe").click(function () {
                var myChart = echarts.init(document.getElementById('main'));
                option = {
                    xAxis: {
                        type: 'category',
                        data: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun']
                    },
                    yAxis: {
                        type: 'value'
                    },
                    series: [{
                        data: [820, 932, 901, 934, 1290, 1330, 1320],
                        type: 'line'
                    }]
                };
                myChart.setOption(option);
            });
            $("#zhefuza").click(function () {
                var myChart = echarts.init(document.getElementById('main'));
                option = {
                    title: {
                        text: '折线图堆叠'
                    },
                    tooltip: {
                        trigger: 'axis'
                    },
                    legend: {
                        data: ['邮件营销', '联盟广告', '视频广告', '直接访问', '搜索引擎']
                    },
                    grid: {
                        left: '3%',
                        right: '4%',
                        bottom: '3%',
                        containLabel: true
                    },
                    toolbox: {
                        feature: {
                            saveAsImage: {}
                        }
                    },
                    xAxis: {
                        type: 'category',
                        boundaryGap: false,
                        data: ['周一', '周二', '周三', '周四', '周五', '周六', '周日']
                    },
                    yAxis: {
                        type: 'value'
                    },
                    series: [
                        {
                            name: '邮件营销',
                            type: 'line',
                            stack: '总量',
                            data: [120, 132, 101, 134, 90, 230, 210]
                        },
                        {
                            name: '联盟广告',
                            type: 'line',
                            stack: '总量',
                            data: [220, 182, 191, 234, 290, 330, 310]
                        },
                        {
                            name: '视频广告',
                            type: 'line',
                            stack: '总量',
                            data: [150, 232, 201, 154, 190, 330, 410]
                        },
                        {
                            name: '直接访问',
                            type: 'line',
                            stack: '总量',
                            data: [320, 332, 301, 334, 390, 330, 320]
                        },
                        {
                            name: '搜索引擎',
                            type: 'line',
                            stack: '总量',
                            data: [820, 932, 901, 934, 1290, 1330, 1320]
                        }
                    ]
                };

                myChart.setOption(option);
            })
            $("#Button1").click(function () {
                //$.ajax({
                //    url: "Data/City.json",type: "get", dataType: "json", success: function (result)
                //    {
                //        $("#TextArea1").val(JSON.stringify(result));
                //    }
                //})
                //使用get方法进行调用
                //$.get("Data/City.json", { "id": 1}, function (result) {
                //    $("#TextArea1").val(JSON.stringify(result));
                //},"json")
                //$.getJSON("Data/City.json", { "id": 1 }, function (result) {
                //    $("#TextArea1").val(JSON.stringify(result));
                //})
                $.post("Handlers/ProcessJsonAjax.ashx", {}, function (result) {
                    $("#TextArea1").val(JSON.stringify(result));
                })

            })
            $("#Button2").click(function () {
                $.ajax({
                    url: "js/demo.js", type: "get", dataType: "script", success: function (result) {
                        $("#TextArea1").val(result);
                    }
                })
            })
            $("#Button3").click(function () {
                $.ajax({
                    url: "Handlers/ProcessAjax.ashx", type: "get", dataType: "text", success: function (result) {
                        $("#TextArea1").val(result);
                    }
                })
            })

            $("#Button4").click(function () {
                $.ajax({
                    url: "Handlers/ProcessJsonAjax.ashx",
                    data: { "id": 1, "name": "123" },
                    type: "get",
                    dataType: "json",
                    beforeSend: function () {
                        $("#loading").show();
                    },
                    success: function (result) {
                        $("#TextArea1").val(JSON.stringify(result));
                    },
                    complete: function () {
                        $("#loading").hide();
                    }
                })
            })
        })
    </script>
</body>
</html>
