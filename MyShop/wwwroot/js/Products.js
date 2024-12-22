//const addEventListener => ("load", filterProducts())
const getData = async() => {

    let search =
    {
        nameSearch: document.querySelector("#nameSearch").value,
        minPrice: parseInt(document.querySelector("#minPrice").value),
        maxPrice: parseInt( document.querySelector("#maxPrice").value)
    }
    return search  
}
   
    const filterProducts = async () => {
        let { nameSearch, minPrice, maxPrice} =await getData()
        let url = `api/products/`;
        if (nameSearch || maxPrice || minPrice) { 
            url += '?'
        if (nameSearch)
            url += `&desc=${nameSearch}`
        if (maxPrice)
            url += `&maxPrice=${maxPrice}`
        if (minPrice)
            url += `&minPrice=${minPrice}`
        }
        try {
            const responsePost = await fetch(url, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                },
                query: {
                    nameSearch: nameSearch,
                    maxPrice: maxPrice,
                    minPrice: minPrice
                }
            });
            if (responsePost.status == 204)
                alert("not found products")
            if (!responsePost.ok) {
                throw new Error(`HTTP error! status:${response.status}`)
            }
            const dataPost = await responsePost.json();
            console.log(dataPost);
            drawProducts(dataPost);
        }
        catch (error) {
            
            alert("יש לכם שגיאה")
        }
        
}
const drawTemplate = async (product) => {
    let tmp = document.getElementById("temp-card");
    let cloneProduct = tmp.content.cloneNode(true)
    cloneProduct.querySelector("img").src = "./pictures/" + product.image
    cloneProduct.querySelector("h1").textContent = product.productName
    cloneProduct.querySelector(".price").innerText = product.price
    cloneProduct.querySelector(".description").innerText = product.descreaptionProduct
    //cloneProduct.querySelector(".button").addEventListener('click', () => { addToCart(product) })
    document.getElementById("PoductList").appendChild(cloneProduct)
}
const drawProducts = async (products) => {
    for (let i = 0; i < products.length; i++) {
        drawTemplate(products[i])
    }
    
    const addToCart = () => {

    }
}