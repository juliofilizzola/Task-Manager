using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository;

public class TodoTaskRepository : ITodoTaskRepository {
    private readonly ApplicationContext _context;

    public TodoTaskRepository(ApplicationContext context) {
        _context = context;
    }

    public async Task<IEnumerable<Domain.Entity.TodoTask>> GetTasksAsync() {
        var todos = await _context.TodoTasks.ToListAsync();

        return todos;
    }

    public async Task<Domain.Entity.TodoTask> GetTaskByIdAsync(string? id) {
        var todos = await _context.TodoTasks.FindAsync(id);

        if (todos == null){
            throw new NullReferenceException();
        }

        return todos;
    }

    public async Task<Domain.Entity.TodoTask> CreateAsync(Domain.Entity.TodoTask todoTask) {
        _context.TodoTasks.Add(todoTask);
        await _context.SaveChangesAsync();
        return todoTask;
    }

    public async Task<Domain.Entity.TodoTask> UpdateAsync(Domain.Entity.TodoTask todoTask) {
        _context.TodoTasks.Update(todoTask);
        await _context.SaveChangesAsync();
        return todoTask;
    }

    public async Task<Domain.Entity.TodoTask> RemoveAsync(Domain.Entity.TodoTask todoTask) {
        _context.TodoTasks.Remove(todoTask);
        await _context.SaveChangesAsync();
        return todoTask;
    }
}