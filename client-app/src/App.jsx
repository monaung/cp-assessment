import { useEffect, useState } from 'react'
import axios from 'axios';
import TodoItem from './components/TodoItem';
import TodoGrid from './components/TodoGrid';
import TodoForm from './components/TodoForm';



function App() {
  const [todoItems, setTodoItems] = useState([]);

  useEffect(() => {
    axios.get('https://localhost:5001/api/todo')
    .then(response => {
        setTodoItems(response.data);
    })
  }, [])


  const add = (title, note) => {
		console.log(title);
	};

  return (
    <div tyle={{
      width: "100%",
      minHeight: 1500,
      background: "white",
      color: "black",
      paddingTop: 20,
    }}>
      <div style={{ maxWidth: 600, margin: "0 auto" }}>
        <h1
        style={{
          display: "flex",
          justifyContent: "space-between",
          alignItems: "center",
          margin: "0 0 20px 0",
        }}>
            To do list!
        </h1>
        <TodoForm add={add}/>
        <TodoItem todoItems={todoItems}/>
      </div>
   </div>
  )
}

export default App
