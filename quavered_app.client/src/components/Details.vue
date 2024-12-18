<template>
  <div class="d-flex vh-100">
    <div class="mt-5 mx-5">
      <h4>Project Details</h4>

      <div v-if="details" class="content mt-5 d-flex gap-5">
        <div>
          <h3>{{ details.repoName }}</h3>
          <p>Owner: <b>{{ details.ownerName }}</b></p>
          <div class="mb-3">
            <a v-bind:href='details.repoUrl'>{{ details.repoUrl }}</a>
          </div>
          <p>{{ details.repoDescription }}</p>
          <div class="mt-5">
            <router-link to="/">Back to List</router-link>
          </div>

        </div>
        <div>
          <p>★ Stargazer Count: {{ details.numStars }}</p>
          <p>Github Id: {{ details.githubId }}</p>
          <p>Date Created: {{ details.createdDate }}</p>
          <p>Last Push Date: {{ details.lastPushDate }}</p>
        </div>
      </div>
    </div>
  </div>
</template>
<style></style>
<script lang="js">

  import { defineComponent } from 'vue';
  import { useRoute } from 'vue-router';

  export default defineComponent({
    name: 'DetailsPage',
    data() {
      return {
        loading: false,
        details: null
      };
    },
    created() {
      //use router to access route.params object to supply id to get details method
      const route = useRoute();
      const id = route.params.id

      // fetch the data when the view is created and the data is
    // already being observed
    this.getDetails(id);

  },
  watch: {
    // call again the method if the route changes
    '$route': 'getDetails'
  },
  methods: {
    getDetails(id) {
      this.details = null;
      this.loading = true;
      //call backend endpoint for get repo details
      fetch('https://localhost:7170/Home/Details/?id='+id)
        .then(r => r.json())
        .then(json => {
          this.details = json;
          this.loading = false;
          return;
        });
    },
  },

});
</script>
