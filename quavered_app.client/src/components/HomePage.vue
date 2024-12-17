<template>
  <div class="d-flex align-items-center">
    <div class="mx-auto">

      <div v-if="post" class="content">
        <h1 class="m-4">Top 100 Starred C# Projects on Github</h1>
        <table class="table table-bordered table-hover">
          <thead>
            <tr>
              <th>Name</th>
              <th>Owner</th>
              <th>Stargazer Count</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="repo in post" :key="repo.id">
              <td>{{ repo.repoName }}</td>
              <td>{{ repo.ownerName }}</td>
              <td>{{ repo.numStars }}</td>
              <td>
                <router-link :to="`/details/${repo.id}`">View Details</router-link>
              </td>
            </tr>

          </tbody>
        </table>
            
      </div>
      <!--<DetailsPage v-if="details"/>-->


    </div>
  </div>
</template>
<style></style>
<script lang="js">
  import { defineComponent } from 'vue';
  //import DetailsPage from './details.vue';

export default defineComponent({
  name: 'HomePage',
  data() {
    return {
      loading: false,
      post: [],
      details: false
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
    fetchData() {
      this.post = null;
      this.loading = true;

      fetch('https://localhost:7170/Home/Index')
        .then(r => r.json())
        .then(json => {
          this.post = json;
          this.loading = false;
          return;
        });
    },
    showDetails() {
      this.details = true;
      this.post = false;
    }
  },
  //components: {
  //  DetailsPage
  //}
});
</script>
