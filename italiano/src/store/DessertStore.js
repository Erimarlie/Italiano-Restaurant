import axios from 'axios'

const DessertStore = {
    state: {
        dessert: []
    },

    getDessert() {
        return this.state.dessert;
    },

    getDessertById(id) {
        return this.state.dessert.find(dessert => dessert.dessertId == id);
    },

    setDessert(dessert) {
        this.state.dessert = dessert;
    },

    setDessertRating(vote, id) {

        // Creates the object to put
        let updateRating = {rating: vote, dessertFK: id};

        // Post to API
        axios.post("https://localhost:5001/dessertratings", updateRating);
    },

    editDessert(item) {

        // Constructing the object from item
        // due to item containing a few more variables than it should
        const edit = {
            dessertId: item.dessertId, 
            name: item.name,
            category: item.category,
            description: item.description,
            price: item.price,
            imgSrc: item.imgSrc 
        }

        // Put to backend
        axios.put("https://localhost:5001/dessertmenu", edit);
    },

    addDessert(item) {

        // Construct object
        const add = {
            name: item.name,
            category: item.category,
            description: item.description,
            price: item.price,
            imgSrc: item.imgSrc
        }

        // Post to backend
        axios.post("https://localhost:5001/dessertmenu", add).then( response => {
            // Push to array
            this.state.dessert.push(response.data);
        });
    },
    deleteDessert(id) {

        // Delete dessert
        axios.delete(`https://localhost:5001/dessertmenu/${id}`);

        // Delete ratings associated with dessert
        axios.delete(`https://localhost:5001/dessertratings/${id}`);
    }
}

export default DessertStore;