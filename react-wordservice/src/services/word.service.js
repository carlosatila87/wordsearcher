import http from "../http-common";
class WordService {
  getTop5() {
    return http.get("/listtop5");
  }
  search(word) {
    return http.get(`/search/${word}`);
  }
  addWord(word) {
    return http.post("/update/", word);
  }
}
export default new WordService();