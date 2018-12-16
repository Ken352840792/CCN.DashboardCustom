<template>
  <div class="search-bar">
    <div class="form-group last-group">
      <div class="form-group" v-for="item in dynamicControls" :key="item.key">
        <input
          class="form-control"
          type="text"
          v-if="item.type=='text'"
          v-model="item.val"
          :placeholder="item.title"
        >
      </div>
    </div>
    <div class="form-group">
      <button type="button" class="btn btn-primary" @click="search">
        <i class="fa fa-search"></i>
        查询
      </button>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {};
  },
  props: ["dynamicControls"],
  methods: {
    search: function() {
      var result = {};
      this.dynamicControls.forEach(item => {
        result[item.key] = item.val;
      });
      this.$emit("callback", result);
    }
  }
};
</script>
