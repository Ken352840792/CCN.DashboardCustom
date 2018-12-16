<template>
    <div class="loading" v-if="state">
      <img src="../assets/images/loading.gif" alt="" >
    </div>
</template>
<style lang="scss" scoped>
.loading {
    width: 100%; 
    height: 100%;
    position: fixed;
    top: 0;
    text-align: center;
    z-index: 999;
  img {
    width: 200px;
    display: block;
    margin: auto;
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    border-radius: 10rem;
  }
}
</style>
<script>
export default {
  props:['state'],
  
}
</script>
