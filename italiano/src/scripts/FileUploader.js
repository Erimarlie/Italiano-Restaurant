import axios from 'axios';

const FileUploader = {
    uploadFile(data) {
        axios({
            method: 'post',
            url: "https://localhost:5001/savepicture",
            data: data,
            config: { 
                headers: { 
                    'Content-Type': 'multipart/form-data' 
                }
            }
        })
    }
}

export default FileUploader;