<template>
  <table :id="id"></table>
</template>
<script>
import "bootstrap-table/dist/bootstrap-table.css";
import "bootstrap-table/dist/bootstrap-table.js";
import "bootstrap-table/dist/locale/bootstrap-table-zh-CN.js";
export default {
  data() {
    return {
      id: Math.random()
        .toString()
        .split(".")[1],
      tableOption: {
        url: "", //请求后台的URL（*）
        method: "get", //请求方式（*）
        striped: true, //是否显示行间隔色
        cache: true, //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
        pagination: true, //是否显示分页（*）
        sortable: true, //是否启用排序
        sortOrder: "asc", //排序方式
        params:{},//额外查询参数
        queryParams: params => {
          var temp = {
            rows: params.limit, //页面大小
            page: params.offset / params.limit + 1, //页码
            sort: params.sort, //排序列名
            sortOrder: params.order //排位命令（desc，asc）
          };
          //Object.assign(temp,params);
          return temp;
        }, //传递参数（*）
        sidePagination: "server", //分页方式：client客户端分页，server服务端分页（*）
        pageNumber: 1, //初始化加载第一页，默认第一页
        pageSize: 10, //每页的记录行数（*）
        pageList: [10, 25, 50, 100], //可供选择的每页的行数（*）
        search: false, //是否显示表格搜索，此搜索是客户端搜索，不会进服务端，所以，个人感觉意义不大
        strictSearch: false,
        showColumns: false, //是否显示所有的列
        showRefresh: false, //是否显示刷新按钮
        minimumCountColumns: 1, //最少允许的列数
        clickToSelect: true, //是否启用点击选中行
        //uniqueId: "ID", //每一行的唯一标识，一般为主键列
        showToggle: false, //是否显示详细视图和列表视图的切换按钮
        cardView: false, //是否显示详细视图
        detailView: false, //是否显示父子表
        responseHandler: function(res) {
          var result = {
            rows: [],
            total: 0
          };
          if (res.success) {
            result.rows = res.result.items;
            result.total = res.result.totalCount;
          }
          return result;
        },
        columns: []
      }
    };
  },
  props: ["option"],
  mounted: function() {
    console.log(this.option);
    var table = $("#" + this.id);
    table.bootstrapTable($.extend({}, this.tableOption, this.option));
    this.tableObj = table;
  }
};
</script>
