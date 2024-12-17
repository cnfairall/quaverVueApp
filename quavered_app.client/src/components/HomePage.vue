<template>
  <div class="d-flex align-items-center">
    <div class="mx-auto">
      <h1>Top 100 Starred C# Projects on Github</h1>

      <div v-if="post" class="content">
        <table class="table table-bordered table-hover">
          <thead>
            <tr>
              <th>Name</th>
              <th>Owner</th>
              <th>Stargazer Count</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="repo in post" :key="repo.id" @click="getDetails(repo.id)">
              <td>{{ repo.repoName }}</td>
              <td>{{ repo.ownerName }}</td>
              <td>{{ repo.numStars }}</td>
            </tr>
          </tbody>
        </table>
      </div>

      
    </div>
  </div>
</template>
<style>
</style>
<script lang="js">
  import { defineComponent } from 'vue';

  export default defineComponent({
    name: 'HomePage',
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
      getDetails(id) {
        this.details = null;
        this.loading = true;

        fetch('https://localhost:7170/Home/Details/?id=' + id)
            .then(r => r.json())
            .then(json => {
              this.details = json;
              this.loading = false;
              console.warn(details);
              return;
            });
        }
    },
  });
</script>
