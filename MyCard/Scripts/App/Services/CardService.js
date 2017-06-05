app.factory('CardService', ['$q','$http', function ($q, $http) {

    return {
        GetAllCards: function () {
            console.log("GetAllCards");
            return $q(function (resolve, reject) {
                $http.get("/api/card")
                    .then(function (res) {
                        resolve(res.data)
                    })
                    .catch(function (err) {
                        reject(err);
                    });
            });
        },
        GetCard: function (id) {
            console.log("GetCard");
            return $q(function (resolve, reject) {
                $http.get("/api/card/"+id)
                    .then(function (res) {
                        resolve(res.data)
                    })
                    .catch(function (err) {
                        reject(err);
                    });
            });
        },
        CreateCard: function (card) {
            console.log("Createcard");
            return $q(function (resolve, reject) {
                $http.post("/api/card", card)
                    .then(function (res) {
                        resolve(res.data)
                    })
                    .catch(function (err) {
                        reject(err);
                    });
            });
        },
        UpdateCard: function (card) {
            console.log("UpdateCard");
            return $q(function (resolve, reject) {
                $http.put("/api/card", card)
                    .then(function (res) {
                        resolve(res.data)
                    })
                    .catch(function (err) {
                        reject(err);
                    });
            });
        },
        DeleteCard: function (id) {
            console.log("DeleteCard");
            return $q(function (resolve, reject) {
                $http.delete("/api/card/"+id)
                    .then(function (res) {
                        resolve(res.data)
                    })
                    .catch(function (err) {
                        reject(err);
                    });
            });
        },
        GetCategories: function () {
            console.log("Categories");
            return $q(function (resolve, reject) {
                $http.get("/api/category")
                    .then(function (res) {
                        resolve(res.data)
                    })
                    .catch(function (err) {
                        reject(err);
                    });
            });

        }
    
    };
}]);