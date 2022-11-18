import Table from "./components/table";
import Form from "./components/form";
import Header from "./components/Header";

import {onMount, createSignal, createEffect} from "solid-js";

function App() {

  const[books, setBooks]= createSignal([]);

  onMount(async () => {
    const res = await fetch(`https://localhost:7082/api/book`);
    console.log(res.body)
    setBooks(await res)
    console.log(books)
  })

  return (
    <div className='flex-initial w-64'>

      <Header/>
      <Form/>
      <Table />

    </div>
  );
}

export default App;
