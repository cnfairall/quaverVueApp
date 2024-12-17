<template>
  <div class="d-flex align-items-center">
    <div class="mx-auto">
      <h1>Details</h1>

      <div v-if="post" class="content">
        <div class="card">
          <div class="card-title">{{ post.repoName }}</div>
          <div class="card-body">
            <p>{{ post.ownerName }}</p>
            <p>{{ post.numStars }}</p>
            <p>{{ post.repoUrl }}</p>
            <p>{{ post.githubId }}</p>
            <p>{{ post.createdDate }}</p>
            <p>{{ post.lastPushDate }}</p>

          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<style></style>
<script lang="js">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'DetailsPage',
  data() {
    return {
      loading: false,
      post: []
    };
  },
  created() {
    // fetch the data when the view is created and the data is
    // already being observed
    this.fetchData();
  },
  watch: {
    // call again the method if the route changes
    '$route': 'fetchData'
  },
  methods: {
    getDetails(id) {
      this.post = null;
      this.loading = true;

      fetch('https://localhost:7170/Home/Details/?id=' + id)
        .then(r => r.json())
        .then(json => {
          this.post = json;
          this.loading = false;
          return;
        });
    }
  },
});
</script>
