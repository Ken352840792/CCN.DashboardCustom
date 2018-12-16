<template>
  <div>
    <div class="box box-default">
      <div class="box-body box-body-resizer">
        <form class="form-inline" id="search-query">
          <vSearch v-bind:dynamicControls="search_controls" @callback="search"></vSearch>
        </form>
        <div class="fixed-table-toolbar text-right">
          <div class="bars pull-right">
            <div id="tbTool">
              <a class="btn btn-primary" @click="editModel">
                <i class="fa fa-plus"></i>
                新建
              </a>
              <button type="button" class="btn btn-primary" id="export">
                <i class="fa fa-download"></i>
                导出
              </button>
            </div>
          </div>
        </div>
        <vTable ref="table" :option="tableOption"></vTable>
      </div>
    </div>
    <div class="container-fluid" id="edit" v-if="isEdit">
      <div class="panel-body">
        <form class="form-horizontal" ref="formBody">
          <div class="form-group row">
            <label class="col-xs-2 control-label">编号：</label>
            <div class="col-xs-4">
              <input type="text" v-model="formData.No" name="No" class="form-control">
            </div>
            <label class="col-xs-2 control-label">名称：</label>
            <div class="col-xs-4">
              <input type="text" v-model="formData.Name" name="Name" class="form-control">
            </div>
          </div>
          <div class="form-group row">
            <label class="col-xs-2 control-label">商品代码：</label>
            <div class="col-xs-4">
              <input type="text" v-model="formData.Code" name="Code" class="form-control">
            </div>
            <label class="col-xs-2 control-label">助记码：</label>
            <div class="col-xs-4">
              <input
                type="text"
                v-model="formData.MnenonicCode"
                name="MnenonicCode"
                class="form-control"
              >
            </div>
          </div>
          <div class="form-group text-center last-group">
            <button type="button" class="btn btn-primary" @click="save">
              <i class="fa fa-save"></i>
              保存
            </button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>
<script>
import vTable from "@c/tables/table";
import vSearch from "@c/tables/dynamic_Search";
import api from "../webapi/user";
import moment from "moment";
import Vue from 'vue';
export default {
  data() {
    console.log(api.get_UserList.options.url);
    return { 
      isEdit: false,
      formData: {
        No: "", //编号
        Name: "", //名称
        Code: "", //编码
        MnenonicCode: "" //助记码
      },
      search_controls: [
        {
          type: "text",
          title: "测试1",
          key: "test1",
          val: ""
        },
        {
          type: "text",
          title: "测试2",
          key: "test2",
          val: ""
        }
      ],
      tableOption: {
        url: api.get_UserList.options.url,
        method: api.get_UserList.options.method,
        columns: [
          { field: "title", title: "标题", formatter: function(val,row) {
               return val;
          } },
          { field: "text", title: "内容" },
          {
            field: "creationTime",
            title: "创建时间",
            align: "center",
            sortable: true,
            formatter: function(val, row) {
              return moment(val).format("YYYY-MM-DD ");
            }
          }
        ]
      }
    };
  },
  watch: {
    isEdit: {
      handler: function(curVal, oldVal) {
        if (curVal) {
          var _ = this;
          setTimeout(function() {
            _.initValidate();
          }, 100);
        }
      }
    }
  },

  methods: {
    search: res => {
      console.log(res);
    },
    initValidate: function() {
      this.validator = $(this.$refs.formBody).bootstrapValidator({
        fields: {
          No: {
            validators: {
              regexp: {
                regexp: /^([\u4e00-\u9fa5-a-zA-Z0-9-_.]{1,50})*$/,
                message: "编号只能为中文、英文字母、数字！"
              },
              notEmpty: {
                message: "编号不可为空！"
              }
            }
          },
          Name: {
            validators: {
              regexp: {
                regexp: /^([\u4e00-\u9fa5-a-zA-Z0-9-_.]{1,50})*$/,
                message: "名称只能为中文、英文字母、数字！"
              },
              notEmpty: {
                message: "名称不可为空！"
              }
            }
          }
        }
      });
    },
    editModel: function() {
      var _ = this;
      _.isEdit = true;
      setTimeout(function() {
        _.layerId = layer.open({
          type: 1,
          title: "测试单据详情",
          maxmin: false,
          area: ['60%', '60%'],
          content: $("#edit"),
          end: function() {
            _.isEdit = false;
          }
        });
      }, 50);
    },
    save: function() {
      console.log($(this.$refs.formBody).data("bootstrapValidator"));

      var validate = $(this.$refs.formBody).data("bootstrapValidator");
      validate.validate();
      if (validate.isValid()) {
        console.log(this.formData);
        layer.close(this.layerId);
      }
    }
  },
  components: { vTable, vSearch }
};
</script>
