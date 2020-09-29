<template>
    <v-row>
        <v-spacer class="hidden-xs-only"></v-spacer>
            <v-col 
                cols="12" 
                lg="8" 
                md="8" 
                sm="10"
            >
                <v-card class="pa-5">
                    <v-img 
                        contain 
                        :src="image" 
                        height="200px"
                        class="mb-10"
                    />

                    <v-form>
                        <v-file-input 
                            clearable 
                            outlined 
                            label="Replace image" 
                            prepend-icon=""
                            id="fileInput"
                            @change="onFileChange"
                        ></v-file-input>

                        <v-text-field
                            v-model="item.name"
                            label="Name"
                            required
                        ></v-text-field>

                        <v-text-field
                            v-model.number="item.price"
                            label="Price"
                            required
                        ></v-text-field>

                        <v-text-field
                            v-model="item.category"
                            label="Category"
                            required
                        ></v-text-field>

                        <v-textarea
                            class="mb-5"
                            v-model="item.description"
                            label="Description"
                            auto-grow
                            rows="3"
                            required
                        ></v-textarea>

                        <v-btn 
                            dark
                            @click="saveEdit" 
                            :color="btnColor"
                        >{{ btnText }}</v-btn>

                        <v-btn 
                            dark
                            to="/admin"
                        >Back</v-btn>
                    </v-form>
                </v-card>
            </v-col>
        <v-spacer class="hidden-xs-only"></v-spacer>
    </v-row>
</template>

<script>
import FileUploader from '@/scripts/FileUploader.js'

import FoodStore from '@/store/FoodStore.js'
import DrinkStore from '@/store/DrinkStore.js'
import DessertStore from '@/store/DessertStore.js'

export default {
    name: "Edit",
    data() {
        return {
            item: [],
            btnColor: "",
            btnText: "Save",
            categoryType: "",
            image: ""
        }
    },
    created() {
        const id = this.$route.params.id;
        const categoryType = this.$route.params.category;
        this.categoryType = categoryType;

        if (categoryType == "food") {
            this.item = FoodStore.getFoodById(id);
        }

        if (categoryType == "drink") {
            this.item = DrinkStore.getDrinkById(id);
        }

        if (categoryType == "dessert") {
            this.item = DessertStore.getDessertById(id);
        }

        // Set the image
        this.image = `https://localhost:5001/images/${this.item.imgSrc}`;
    },
    methods: {
        onFileChange(file) {
            // On filechange to send to imagePreview
            this.imagePreview(file)
        },
        imagePreview(img) {
            // To preview the image before upload
            const reader = new FileReader;

            reader.onload = (e) => {
                this.image = e.target.result;
            }

            // If file is cleared, return to original image
            // else preview image
            if (!img) {
                this.image = `https://localhost:5001/images/${this.item.imgSrc}`;
            } else {
                reader.readAsDataURL(img);
            }
        },
        saveEdit() {
            // Filename to store in the database
            const fileName = document.getElementById("fileInput").value.slice(12);

            // // The file itself
            const file = document.getElementById("fileInput");

            // Set the filename if there is a new one
            // and upload the file
            if (fileName.length != 0) {

                // Set the new filename
                this.item.imgSrc = fileName;

                // Create formdata
                let data = new FormData();

                //Append new file to formdata
                data.append("file", file.files[0]);

                // Upload the file
                FileUploader.uploadFile(data);
            }

            // Put the edited item
            // calling a different method depending on categoryType
            if (this.categoryType == "food") {
                FoodStore.editFood(this.item);
            }

            if (this.categoryType == "drink") {
                DrinkStore.editDrink(this.item);
            }

            if (this.categoryType == "dessert") {
                DessertStore.editDessert(this.item);
            }

            // Change color and text of button to indicate success
            this.btnText = "Saved";
            this.btnColor = "green";
        }
    }
}
</script>