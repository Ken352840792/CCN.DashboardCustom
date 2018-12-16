<template>
  <div id="app">
    <div class="content-wrapper clear">
      <router-view/>
    </div>
    <!-- /.content-wrapper -->
    <footers></footers>
  </div>
</template>
 
<script>
import footers from "@c/footer";
import "@p/font-awesome/css/font-awesome.min.css"
import "@p/layer-v3.1.1/theme/default/layer.css"
import "@p/layer-v3.1.1/layer.js"
import "@/assets/css/basePage.css";
export default {
  methods: {
    autoWindow: function() {
      var windowHeight = $(window).height() - 51;
      $(".box-body-resizer").css({ "min-height": windowHeight });
    }
  },
  mounted: function() {
    var _ = this;
    _.autoWindow();
    $(window).resize(function() {
      _.autoWindow();
    });
  },
  components:{
    footers
  }
};
</script>


